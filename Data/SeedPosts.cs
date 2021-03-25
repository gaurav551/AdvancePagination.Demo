using System.Linq;
using System.Threading.Tasks;
using AdvancePagination.Demo.Models;
using Microsoft.AspNetCore.Identity;

namespace AdvancePagination.Demo.Data
{
    public static class PostsSeeder
    {

        //This method gets invoked from static main method to create and add SamplePosts to db.
        public static async Task SeedPosts(AppDbContext context)
        {
            //Check if there is any Data
            if (!context.Posts.Any())
            {
               int postsToSeed = 2500;
               int i = 0;
               while(i < postsToSeed)
               {
                 Post p = new Post(){
                    // Id=i+1, 
                     Title= "Post Title " + i, 
                     Description = "This is Description " + i,
                     ImagePath = "/pathToImage "+ i,
                     CreatedBy = "user "+i};
                     context.Posts.Add(p);
                      System.Console.WriteLine("Adding Post " + i);
                     await context.SaveChangesAsync();   
                     i++;
               } 
              
                        

               
            }
        }
        


    }
}