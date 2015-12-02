using NakkeNet.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

public interface IUsersRepository
{
    IQueryable<User> All { get; }
    IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties);
    User Find(int id);
    void InsertOrUpdate(User user);
    void InsertOrUpdate(User user, HttpPostedFileBase image);
    void Delete(int id);
    void Save();
    void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile);
}

public class UsersRepository : IUsersRepository
{
    ApplicationDbContext context =
        new ApplicationDbContext();

    public IQueryable<User> All
    {
        get { return context.Users; }
    }

    public IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
    {
        IQueryable<User> query = context.Users;
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return query;
    }

    public User Find(int id)
    {
        User user = context.Users.Find(id);
        return user;
    }

    public void InsertOrUpdate(User user)
    {
        if (user.UserId == 0) //new
        {
            context.Users.Add(user);

            Save();
        }
        else //edit
        {
            context.Entry(user).State =
System.Data.Entity.EntityState.Modified;
            //save to db.
            Save();
        }
    }
    public void InsertOrUpdate(User user, HttpPostedFileBase image)
    {
        if (user.UserId == 0) //new
        {
            context.Users.Add(user);
//          user.SaveImage(image, HttpContext.Current.Server.MapPath("~"), "/ProfileImages/");
            Save();
        }
        else //edit
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            
            //save to db.
            Save();
        }
    }

    public void Delete(int id)
    {
        User user = Find(id);

        context.Entry(user).State =
        EntityState.Deleted;
        Save();
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
    {
        throw new NotImplementedException();
    }
}