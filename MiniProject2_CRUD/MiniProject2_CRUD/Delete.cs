using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2_CRUD
{
    internal class Delete
    {
        public static void DeleteProduct(ProductContext db, int id)
        {
            // delete from db
            Product productDelete = db.Products.Where(product => product.Id == id).FirstOrDefault();
            if (productDelete != null)
            {
                db.Products.Remove(productDelete);
                db.SaveChanges();
                Console.WriteLine($"The product with id:{id} has been deleted");
            }
            else
            {
                Console.WriteLine("The Selected product doesn't exist");
            }
        }
    }

}
