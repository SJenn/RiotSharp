using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RiotSharp.Test
{
    [TestClass]
    public class StatusRiotApiTest : CommonTestBase
    {
        private static readonly StatusRiotApi Api = StatusRiotApi.GetInstance(ApiKey);

        [TestMethod]
        [TestCategory("StatusRiotApi"), TestCategory("Async")]
        public void GetShardStatusAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var shardStatus = Api.GetShardStatusAsync(Summoner1And2Region);

                Assert.AreEqual(StatusRiotApiTestBase.Platform.ToString().ToLower(),
                    shardStatus.Result.RegionTag);
            });
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointIncident_Test()
        {
            try
            {
                var incident = new Incident
                {
                    Active = true,
                    CreatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    Id = 10545,
                    Updates = new List<Message>() { new Message { Severity = "info",
                    Author = "",
                    CreatedAt =  DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    Translations = new List<Translation>() { new Translation { Locale = Language.fr_FR,
                        Content = "Nous sommes conscients du problème qui empêche les transferts de régions, et nous avons désactivé cette fonctionnalité pendant que nous travaillons à le corriger.",
                        UpdatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture)
                        } },
                    UpdatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    Content = "We're aware of a problem causing region transfers to fail, and have disabled them while we work on a fix.",
                    Id = "5c0a03383f2b830100008cb9"
                } }
                };
            }
            catch (Exception e){
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointMessage_Test()
        {
            try
            {
                var message = new Message { Severity = "info",
                    Author = "",
                    CreatedAt =  DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    Translations = new List<Translation>() { new Translation { Locale = Language.fr_FR,
                        Content = "Nous sommes conscients du problème qui empêche les transferts de régions, et nous avons désactivé cette fonctionnalité pendant que nous travaillons à le corriger.",
                        UpdatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture)
                        } },
                    UpdatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                    Content = "We're aware of a problem causing region transfers to fail, and have disabled them while we work on a fix.",
                    Id = "5c0a03383f2b830100008cb9"
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointService_Test()
        {
            try
            {
                var service = new Service
                {
                    Status = "online",
                    Incidents = new List<Incident>(),
                    Name = "Game",
                    Slug = "game"
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointShard_Test()
        {
            try
            {
                var shard = new Shard
                {
                    Name = "EU West",
                    RegionTag = "eu",
                    Hostname = "prod.euw1.lol.riotgames.com",
                    Slug = "euw",
                    Locales = new List<Language> { Language.fr_FR }
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointShardStatus_Test()
        {
            try
            {
                var shard = new ShardStatus
                {
                    Services = new List<Service>()
                    {
                        new Service {
                            Status = "online",
                            Incidents = new List<Incident>(),
                            Name = "Game",
                            Slug = "game"
                        }
                    }
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void StatusEndpointTranslation_Test()
        {
            try
            {
                var translation = new Translation
                {
                    Locale = Language.fr_FR,
                    Content = "Nous sommes conscients du problème qui empêche les transferts de régions, et nous avons désactivé cette fonctionnalité pendant que nous travaillons à le corriger.",
                    UpdatedAt = DateTime.ParseExact("2018-12-07T05:20:56.043Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture)
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void MatchEndpointBannedChampion_Test()
        {
            try
            {
                var banned = new BannedChampion
                {
                    ChampionId = 55,
                    PickTurn = 1
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void MatchEndpointMastery_Test()
        {
            try
            {
                var mastery = new Mastery
                {
                    MasteryId = 6114,
                    Rank = 5
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [TestCategory("StatusRiotApi")]
        public void MatchEndpointRune_Test()
        {
            try
            {
                var rune = new Rune
                {
                    RuneId = 5253,
                    Rank = 9
                };
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
