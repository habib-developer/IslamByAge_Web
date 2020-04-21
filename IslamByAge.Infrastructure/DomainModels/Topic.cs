using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IslamByAge.Infrastructure.DomainModels
{
    [FirestoreData]
    public class Topic
    {
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string Body { get; set; }
        [FirestoreProperty]
        public bool IsActive { get; set; }
    }
}
