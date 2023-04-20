using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RecipeClass
    {
        public ObjectId Id { get; set; }

        public string Title { get; set; }    

        public string Summary { get; set; }

        public string Image { get; set; }

        public int Minutes { get; set; }
    }
}
