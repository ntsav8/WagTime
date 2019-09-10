﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WagtimeTest.Data;
using WagtimeTest.ViewModels.Client;

namespace WagtimeTest.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext context;

        public ClientController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<ClientListItemViewModel> viewModelClients = ClientListItemViewModel.GetClientListItemViewModel(context);
            return View(viewModelClients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ClientCreateViewModel model = new ClientCreateViewModel(context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ClientCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
        }


        public IActionResult Details(int id)
        {

            ClientDetailsViewModel clientDetailsViewModel = ClientDetailsViewModel.GetClientDetailsViewModel(context, id);
            return View(clientDetailsViewModel);
        }
    }
}