using System;
using MySql.Data.MySqlClient;

namespace Web2020Project.Model
{
    public class Producer
    {
        private String producerID;
        private String producerName;
        private String producerAddress;

        public Producer()
        {
        }

        public Producer(string producerId, string producerName, string producerAddress)
        {
            producerID = producerId;
            this.producerName = producerName;
            this.producerAddress = producerAddress;
        }

        public string ProducerId
        {
            get => producerID;
            set => producerID = value;
        }

        public string ProducerName
        {
            get => producerName;
            set => producerName = value;
        }

        public string ProducerAddress
        {
            get => producerAddress;
            set => producerAddress = value;
        }

        public Producer GetProducer(MySqlDataReader reader)
        {
            ProducerId = reader.GetString("manhacungcap");
            ProducerName = reader.GetString("tennhacungcap");
            ProducerAddress = reader.GetString("diachi");
            return this;
        }
    }
}