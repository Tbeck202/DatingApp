using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // I don't really know what [ApiController] is, but we need it and it was added manually
    [ApiController]
    /* 
        This is the route logic class: ie. "foo.com/api/users" 
        In here we'll define what happenes for each type of Users request, ie. get, post, put, delete
    */
    [Route("api/[controller]")]
    // "ControllerBase" was added manually and uses "Microsoft.AspNetCore.Mvc;"
    public class UsersController : ControllerBase
    {
        /* 
            This is the constructor 
            "DataContext" uses "API.Data" and "_context" gives us access to the DB
        */
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        /*
            This defines the Users GET route: api/users
            "ActionResult" defines what is returned on request
            "<IEnumerable<AppUser>>" means we're returning an enum list of "AppUser"
            There are other ways to return lists in .NET, like "List", 
            but we're using a simple enum list here beause "List" has a ton of attached methods that we don't need.
            Furthermore, add "async Task<>" to make the Db query asynchronous. 
            Task<> uses System.Threading.Tasks;
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            /* 
                Query the Db and return a list of users
                "ToListAsync()" uses "Microsoft.EntityFrameworkCore;"
            */
            return await _context.Users.ToListAsync();
        }

        /* 
            This is the GET route for finding a specifc user: api/users/1
            We're only returning one user so we just define what will be returned with "ActionResult<AppUser>"
            Add "async Task<>" to make the Db query asynchronous. 
            Task<> uses System.Threading.Tasks;
        */
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            /* 
                Query the Db and return a specific user by id
            */
            return await _context.Users.FindAsync(id);
        }
    }
}