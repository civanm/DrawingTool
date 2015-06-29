using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrawinLibrary;
using DrawingTool.Models;

namespace DrawingTool.Controllers
{
    public class DrawController : ApiController
    {
        // POST api/draw
        public string Post([FromBody]string input)
        {
            var draw = new Draw();

            return draw.ReadLines(input);
        }

    }
}
