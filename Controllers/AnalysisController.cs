using MarkelApp.Data;
using MarkelApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarkelApp.Controllers
{
    public class AnalysisController : Controller
    {
        // DEPENDENCY INJECTION TO BRING IN ApplicationDbContext
        private readonly ApplicationDbContext _db;
        public AnalysisController(ApplicationDbContext db)
        {
            _db = db;
        }

        // LIST OF ANALYSES VIEW
        public IActionResult Index()
        {
            IEnumerable<Analysis> objList = _db.Analysis;
            return View(objList);
        }

        // CREATE ANALYSIS VIEW
        public IActionResult Create()
        {
            return View();
        }

        // CREATE ANALYSIS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int SubmissionId, string AggLimit, Analysis obj)
        {
            // CREATE A DICTIONARY TO STORE CURRENCY MARKERS TO 0'S
            var currencyMarkers = new Dictionary<string, string>
            {
                { "K", "000" },
                { "M", "000000" },
                { "B", "000000000" }
            };
            
            // REGEX PATTERN TO MATCH WITH
            Regex expression = new Regex(@"^[0-9]+[^I]?[a-z|A-Z]{1}$");

            // VERIFY A FORWARD SLASH EXISTS TO SPLIT THE DATA ON
            if (AggLimit.Contains("/"))
            {
                // SPLIT THE STRING ON THE FORWARD SLASH
                string[] AggSplit = AggLimit.Split('/');

                // VERIFY THE SPLIT ONLY CREATED TWO LIST ITEMS
                if (AggSplit.Count() == 2)
                {

                    // SET THE AggLimits BASED ON INDEX IN LIST AND CALL ToUpper
                    string AggLimit_1 = AggSplit[0].ToUpper();
                    string AggLimit_2 = AggSplit[1].ToUpper();

                    // IF THE ITEM IS A VALID INTEGER, PASS THE VALID ITEM ALONG
                    // OTHERWISE CHECK PATTERN MATCH AND VERIFY THE LAST CHARACTER 
                    // IS A VALID DICTIONARY KEY AND REPLACE LAST CHARACTER WITH
                    // DICTIONARY VALUE
                    long longAggLimit_1 = 0;
                    bool limitCanConvert_1 = long.TryParse(AggLimit_1, out longAggLimit_1);
                    if (limitCanConvert_1 == true)
                        obj.AggLimit_1 = longAggLimit_1;
                    else
                    {
                        if (currencyMarkers.ContainsKey(AggLimit_1.Last().ToString()) && expression.IsMatch(AggLimit_1))
                        {
                            string AggLimit_1_lastCharacter = AggLimit_1.Last().ToString();
                            AggLimit_1 = AggLimit_1.Replace(AggLimit_1_lastCharacter, currencyMarkers[AggLimit_1_lastCharacter]);
                            obj.AggLimit_1 = long.Parse(AggLimit_1);
                        }
                        else
                        {
                            // TO DO - CREATE A PARTIAL VIEW TO RETURN ERROR
                            return View();
                        }
                    }

                    // IF THE ITEM IS A VALID INTEGER, PASS THE VALID ITEM ALONG
                    // OTHERWISE CHECK PATTERN MATCH AND VERIFY THE LAST CHARACTER 
                    // IS A VALID DICTIONARY KEY AND REPLACE LAST CHARACTER WITH
                    // DICTIONARY VALUE
                    long longAggLimit_2 = 0;
                    bool limitCanConvert_2 = long.TryParse(AggLimit_2, out longAggLimit_2);
                    if (limitCanConvert_2 == true)
                        obj.AggLimit_2 = longAggLimit_2;
                    else
                    {
                        if (currencyMarkers.ContainsKey(AggLimit_2.Last().ToString()) && expression.IsMatch(AggLimit_2))
                        {
                            string AggLimit_2_lastCharacter = AggLimit_2.Last().ToString();
                            AggLimit_2 = AggLimit_2.Replace(AggLimit_2_lastCharacter, currencyMarkers[AggLimit_2_lastCharacter]);
                            obj.AggLimit_2 = long.Parse(AggLimit_2);
                        }
                        else
                        {
                            // TO DO - CREATE A PARTIAL VIEW TO RETURN ERROR
                            return View();
                        }
                    }
                }
                
            }
            else
            {
                // TO DO - CREATE A PARTIAL VIEW TO RETURN ERROR
                return View();
            }
            
            // TO DO - VERIFY THAT SUBMISSION ID IS VALID
            obj.SubmissionId = SubmissionId;

            _db.Analysis.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
