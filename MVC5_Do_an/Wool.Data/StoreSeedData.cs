using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<WoolEntities>
    {
        protected override void Seed(WoolEntities context)
        {
            GetCategories().ForEach(C => context.Categories.Add(C));

            context.Commit();
        }

        private static List<Category> GetCategories()
        {
            return new List<Category> {
                new Category {
                    Name = "Socks"
                },
                new Category {
                    Name = "Hats"
                }
            };
        }
    }
}
