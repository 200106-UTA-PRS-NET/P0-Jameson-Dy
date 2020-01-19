using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PizzaBox.Domain;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuSystemManager.MainMenu();
        }
    }
}
