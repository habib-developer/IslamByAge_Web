using Google.Cloud.Firestore;
using IslamByAge.Infrastructure.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IslamByAge.Infrastructure.Data
{
    public class IslamByAgeFirestoreDB
    {
        private readonly FirestoreDb db;
        public IslamByAgeFirestoreDB()
        {
            db = FirestoreDb.Create();
        }
        public CollectionReference Topics
        {
            get { return db.Collection("Topics"); }
        }
        public async Task<bool> InsertTopic(Topic topic)
        {
            try
            {
                var docRef = Topics.Document();
                await docRef.SetAsync(topic);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateTopic(Topic topic)
        {
            try
            {
                var docRef = Topics.Document(topic.Id.ToString());
                await docRef.SetAsync(topic, SetOptions.Overwrite);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Topic> GetTopicById(string id)
        {
            var docRef = Topics.Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Topic>();
            }
            else
            {
                return null;
            }
        }
        public async Task<List<Topic>> GetTopics()
        {
            var snapshot = await Topics.GetSnapshotAsync();
            var topics = new List<Topic>();
            foreach (var item in snapshot.Documents)
            {
                topics.Add(item.ConvertTo<Topic>()); 
            }
            return topics;
        }
    }
}
