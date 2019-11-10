using E.Common.Repository;
using E.Common.UOW;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;

namespace XUnit.ECommonTest
{
    public class UowTest
    {
        private SqliteConnection connection;
        private DbContextOptions<TestDbContext> options;

        public UowTest()
        {
            this.connection = new SqliteConnection("DataSource=:memory:");
            if (connection.State==System.Data.ConnectionState.Open) { connection.Close(); }
            this.options = new DbContextOptionsBuilder<TestDbContext>().UseSqlite(connection).Options;
        }

        [Fact]
        public void Add_Single_User()
        {


            try
            {
                connection.Open();
                using (connection)
                {
                   
                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<UserTest>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new UserTest
                        {
                            id = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        int result = _uow.SaveChanges();
                        Assert.Equal(1, result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }


        }


        [Fact]
        public void Add_Multiple_Users()
        {
            try
            {
                connection.Open();
                using (connection)
                {
                   

                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<UserTest>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new UserTest
                        {
                            id = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        var user2 = new UserTest
                        {
                            id = 2,
                            Name = "mehmet",
                            Surname = "soylu"
                        };
                        var user3 = new UserTest
                        {
                            id = 3,
                            Name = "ayþe",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        _repo.Add(user2);
                        _repo.Add(user3);
                        int result = _uow.SaveChanges();
                        Assert.Equal(3, result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }


        }


        [Fact]
        public void Update_User()
        {
            try
            {
                connection.Open();
                using (connection)
                {
                 
                    using (var context = new TestDbContext(options))
                    {
                        var _repo = new Repository<UserTest>(context);
                        var _uow = new UnitOfWork(context);

                        var user = new UserTest
                        {
                            id = 1,
                            Name = "ahmet",
                            Surname = "soylu"
                        };
                        var user2 = new UserTest
                        {
                            id = 2,
                            Name = "mehmet",
                            Surname = "soylu"
                        };
                        var user3 = new UserTest
                        {
                            id = 3,
                            Name = "ayþe",
                            Surname = "soylu"
                        };
                        _repo.Add(user);
                        _repo.Add(user2);
                        _repo.Add(user3);
                        int result = _uow.SaveChanges();

                        var _user = _repo.Get(u => u.id == 1).FirstOrDefault();
                        _user.Name = "kemal";
                        _uow.SaveChanges();
                        Assert.Equal("kemal", _repo.Get(u => u.id == 1).FirstOrDefault().Name);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { connection.Close(); }
        }

    }
}
