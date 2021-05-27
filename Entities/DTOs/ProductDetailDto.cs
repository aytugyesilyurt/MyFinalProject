using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //IEntity bir db tablosusun sen demek fakat burda joinler de olabilir ,o yüzden bu IDto olur , gidip contexte eklenmesin 
    // Generate new type ordan özellikleri seçerek oluştururuz. public / interface / Core / entities\Idto.cs

    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }

    }
}
