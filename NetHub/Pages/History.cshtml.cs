using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;


using NetHub.Models;
using NetHub.Models.ViewModels;

namespace NetHub.Pages
{
    public class HistoryModel : PageModel
    {
        public IList<MovieHistory> Watched { get; set; }
    }
}