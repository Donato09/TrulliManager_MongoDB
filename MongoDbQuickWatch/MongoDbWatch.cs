using MongoDB.Bson;
using MongoDB.Driver;
using System;
using TrulliManager.Database;

namespace MongoDbQuickWatch
{
    public class MongoDbWatch : IMongoDbWatch
    {
        public readonly IMongoDatabase _db = null;

        public MongoDbWatch(ITrulliManagerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            if (client != null)
                _db = client.GetDatabase(settings.DatabaseName);
        }

        public async void Watch()
        {
            //Get the whole document instead of just the changed portion
            ChangeStreamOptions options = new ChangeStreamOptions() { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            // We are just watching insert operation
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>().Match("{ operationType: { $in: [ 'replace', 'insert', 'update' ] } }");

            IMongoCollection<BsonDocument> collection = _db.GetCollection<BsonDocument>("Properties");

            var changeStream = collection.Watch(pipeline, options).ToEnumerable().GetEnumerator();

            //using (var cursor = await _db.WatchAsync())
            //{
            //    await cursor.ForEachAsync(change =>
            //    {
            //        cursor.MoveNextAsync();
            //        // process change event

            //        var printQueueEntry = cursor.Current.ToBsonDocument();
            //    });
            //}

            //// start the watch on the collection
            using (var printQueueStream = changeStream)
            {
            //    // loop is required so that we are always connected and looking for next document
                while (true)
                {
                    try
                    {
                        // If we get the document, serialize to our model
                        printQueueStream.MoveNext();

                        var printQueueEntry = printQueueStream.Current.FullDocument;

                        //var printQueueEntry = DeSerializePrintQueueKOTDocument(printQueueStream.Current.FullDocument);
                        //// We are locking the collection before inserting the latest record to avoid multiple insert
                        //lock (_lockKOTEntry)
                        //{
                        //    if (!_readyToBePickedKOTList.ContainsKey(printQueueEntry.RestaurantId))
                        //        _readyToBePickedKOTList.Add(printQueueEntry.RestaurantId, new List());
                        //    _readyToBePickedKOTList[printQueueEntry.RestaurantId].Add(printQueueEntry);
                        //}
                        //unHandledExceptionCounter = 0;
                    }
                    catch (Exception ex)
                    {
                        // in case of some error we are incrementing the counter
                        //unHandledExceptionCounter++;
                        //if (unHandledExceptionCounter == 1)
                        //{
                        //    logger.Error($"Unhandled exception with the counter {unHandledExceptionCounter}.", ex);
                        //}
                        //else if (unHandledExceptionCounter > 10)
                        //{
                        //    logger.Error($"Too many unhandled exception with the counter {unHandledExceptionCounter}. We will break the loop.", ex);
                        //    break;
                        //}
                    }
                }
            }
        }
    }
}
