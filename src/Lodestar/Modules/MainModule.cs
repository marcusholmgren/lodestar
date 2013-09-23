using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lodestar.Modules
{
    public sealed class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => View["index.html"];


            Get["/left"] = _ => Response.AsJson(new InfoModel[] {
                new InfoModel { Id = Guid.NewGuid(),  Title = "L1", Message = "First item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "L2", Message = "Second item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "L3", Message = "Third item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "L4", Message = "Fourth item" }
            });


            Get["/right"] = _ => Response.AsJson(new InfoModel[] {
                new InfoModel { Id = Guid.NewGuid(), Title = "R1", Message = "First item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "R2", Message = "Second item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "R3", Message = "Third item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "R4", Message = "Fourth item" },
                new InfoModel { Id = Guid.NewGuid(), Title = "R5", Message = "Fifth item" }
            });


            Get["/async", true] = async (parameters, token) =>
            {
                await System.Threading.Tasks.Task.Run(() =>  System.Threading.Thread.Sleep(2000));
                return Response.AsText("Helloe");
            };
        }
    }

    public sealed class InfoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}