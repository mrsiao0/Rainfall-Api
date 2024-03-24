using Rainfall.Api.Domain.ViewModel;

namespace Rainfall.Tests.Mocks
{
    public static class MockStationServiceQuery
    {
        public static StationsReading StationReadings()
        {
            return new StationsReading
            {
                Context = "http://environment.data.gov.uk/flood-monitoring/meta/context.jsonld",
                Meta = new MetaInfo
                {
                    Comment = "Status: Beta service",
                    Documentation = "http://environment.data.gov.uk/flood-monitoring/doc/reference",
                    HasFormat = new string[] {
                        "http://environment.data.gov.uk/flood-monitoring/id/stations/E7050/readings.csv",
                        "http://environment.data.gov.uk/flood-monitoring/id/stations/E7050/readings.rdf",
                        "http://environment.data.gov.uk/flood-monitoring/id/stations/E7050/readings.ttl",
                        "http://environment.data.gov.uk/flood-monitoring/id/stations/E7050/readings.html"
                    },
                    Licence = "http://www.nationalarchives.gov.uk/doc/open-government-licence/version/3/",
                    Publisher = "Environment Agency",
                    Version = "0.9",
                },
                Items = new List<StationInfo>
                {
                    new StationInfo
                    {
                        DateTime = DateTime.Parse("2024-03-08T05:15:00Z"),
                        Id = "http://environment.data.gov.uk/flood-monitoring/data/readings/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-03-08T05-15-00Z",
                        Measure ="http://environment.data.gov.uk/flood-monitoring/id/measures/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm",
                        Value =0
                    },

                    new StationInfo
                    {
                        DateTime = DateTime.Parse("2024-03-08T05:15:00Z"),
                        Id = "http://environment.data.gov.uk/flood-monitoring/data/readings/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-02-09T00-00-00Z",
                        Measure ="http://environment.data.gov.uk/flood-monitoring/id/measures/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm",
                        Value =0
                    },

                    new StationInfo
                    {
                        DateTime = DateTime.Parse("2024-02-09T00:15:00Z"),
                        Id = "http://environment.data.gov.uk/flood-monitoring/data/readings/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm/2024-02-09T00-15-00Z",
                        Measure ="http://environment.data.gov.uk/flood-monitoring/id/measures/E7050-rainfall-tipping_bucket_raingauge-t-15_min-mm",
                        Value = 0.2
                    }
                }
                
            };
        }
    }
}
