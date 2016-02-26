using Nancy;
using HairSalon;
using System.Collections.Generic;
using System;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/stylists"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };

      Get["/stylists/new"] = _ =>
      {
        return View["stylists_form.cshtml"];
      };

      Post["/stylists/new"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };

      Get["/stylists/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistClients = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("clients", stylistClients);
        return View["stylist.cshtml", model];
      };

      Post["/stylists/delete"] = _ =>
      {
        Stylist.DeleteAll();
        return View["cleared.cshtml"];
      };

      Get["stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", selectedStylist];
      };
      Patch["stylist/edit/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Update(Request.Form["stylist-name"]);
        return View["sucess.cshtml"];
      };

      Get["stylist/delete/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        return View["stylist_delete.cshtml", selectedStylist];
      };
      Delete["stylist/delete/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Delete();
        return View["success.cshtml"];
      };

      Get["/clients"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };

      Get["/clients/new"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View ["clients_form.cshtml", allStylists];
      };
      Post["/clients/new"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"],Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };

      Get["/client/edit/{id}"] = parameters =>
      {
      Client selectedClient = Client.Find(parameters.id);
      return View["client_edit.cshtml", selectedClient];
      };
      Patch["/client/edit/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Update(Request.Form["client-name"]);
        return View["success.cshtml"];
      };

      Get["/client/delete/{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        return View["client_delete.cshtml", selectedClient];
      };
      Delete["/client/delete{id}"] = parameters =>
      {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        return View["success.cshtml"];
      };
    }
  }
}
