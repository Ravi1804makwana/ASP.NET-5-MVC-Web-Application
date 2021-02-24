using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Models;

namespace MyWeb.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Games> Games { get; set; }
    }
}