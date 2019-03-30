﻿using MongoDB.Driver;
using RF.Identity.Domain.Entities.Data;
using RF.UserRegistration.App.Helpers.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RF.UserRegistration.App.Helpers.Data
{
    public class UserActivationDataHelper : DBBaseHelper
    {
        public UserActivationDataHelper(MongoDBConnectionInfo databaseInfo) : base(databaseInfo)
        {
        }

        public User GetUser(string email)
        {
            IMongoCollection<User> userCollection = GetMongoDatabase().GetCollection<User>(GetMongoDBConnectionInfo().UserCollection);
            User result = null;
            result = userCollection.AsQueryable<User>().Where<User>(e => e.email == email).SingleOrDefault();
            return result;
        }

        public async Task RegisterUserAsync(User entity)
        {
            DateTime datetimestamp = DateTime.UtcNow;
            IMongoCollection<User> userCollection = GetMongoDatabase().GetCollection<User>(GetMongoDBConnectionInfo().UserCollection);
            entity.created_date = datetimestamp;
            entity.updated_date = datetimestamp;
            await userCollection.InsertOneAsync(entity);
        }
    }
}