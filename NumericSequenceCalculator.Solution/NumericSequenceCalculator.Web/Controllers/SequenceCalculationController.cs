using NumericSequenceCalculator.Web.App_Start;
using NumericSequenceCalculator.Web.Core;
using NumericSequenceCalculator.Web.Contracts;
using NumericSequenceCalculator.Web.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NumericSequenceCalculator.Web.Controllers
{
    public class SequenceCalculationController : Controller
    {
        private ISequenceGeneratorFactory _sequenceGeneratorFactory;
        public SequenceCalculationController(ISequenceGeneratorFactory sequenceGeneratorFactory)
        {
            _sequenceGeneratorFactory = sequenceGeneratorFactory;
        }
        
        public ActionResult Index()
        {
            ViewBag.GetSequenceInputViewModel = new GetSequenceInputViewModel();

            return View();
        }

        //[ValidateInput(true)]
        public ActionResult GenerateSequences(GetSequenceInputViewModel inputVM)
        {
            //if (!ModelState.IsValid) return RedirectToAction("Index");
                
            var seqViewModel = new NumericSequenceViewModel();

            //var sequenceGenerators = GetSequenceGenerators().ToList();
            var sequenceGenerators = _sequenceGeneratorFactory.GetSequenceGenerators();
            try
            {
                sequenceGenerators.ForEach(t =>
                {
                    seqViewModel.Sequences.Add(t.Name, t.GetSequence(inputVM.Input));
                });

                seqViewModel.Limit = inputVM.Input;
            }
            catch (Exception ex)
            {
                ViewBag.StatusMessage = ex.Message;
                ViewBag.Status = "Invalid";
            }
            ViewBag.GetSequenceInputViewModel = inputVM;

            return View(seqViewModel);
        }
    }
}