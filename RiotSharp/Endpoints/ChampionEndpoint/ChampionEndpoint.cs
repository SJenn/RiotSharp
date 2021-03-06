﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.ChampionEndpoint
{
    /// <summary>
    /// Implementation of the IChampionEndpoint interface.
    /// </summary>
    /// <seealso cref="RiotSharp.Endpoints.Interfaces.IChampionEndpoint" />
    public class ChampionEndpoint : IChampionEndpoint
    {
        private const string PlatformRootUrl = "/lol/platform/v3";
        private const string ChampionsUrl = "/champions";
        private const string ChampionRotationUrl = "/champion-rotations";
        private const string IdUrl = "/{0}";
        private Dictionary<Region, ChampionRotation> rotationCache = new Dictionary<Region, ChampionRotation>();

        private readonly IRateLimitedRequester _requester;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionEndpoint"/> class.
        /// </summary>
        /// <param name="requester">The requester.</param>
        public ChampionEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        /// <inheritdoc />
        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + ChampionsUrl, region,
                new List<string> { $"freeToPlay={freeToPlay.ToString().ToLower()}" }).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        /// <inheritdoc />
        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await _requester.CreateGetRequestAsync(
                PlatformRootUrl + ChampionsUrl + string.Format(IdUrl, championId), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Champion>(json);
        }

        /// <inheritdoc />
        public async Task<ChampionRotation> GetChampionRotationAsync(Region region)
        {
            if (!rotationCache.ContainsKey(region))
            {
                var json = await _requester.CreateGetRequestAsync(PlatformRootUrl + ChampionRotationUrl, region
                    ).ConfigureAwait(false);
                var val = JsonConvert.DeserializeObject<ChampionRotation>(json);
                rotationCache.Add(region, val);
                return val;
            }
            else {
                ChampionRotation val;
                rotationCache.TryGetValue(region, out val);
                return val;
            }
        }

        /// <inheritdoc />
        public ChampionRotation GetChampionRotationMock(Region region)
        {
            var json = "{\"freeChampionIds\": [13,34,35,44,51,60,68,80,84,99,126,150,161,202],\"freeChampionIdsForNewPlayers\": [18,81,92,141,37,238,19,45,25,64],\"maxNewPlayerLevel\": 10}";
            return JsonConvert.DeserializeObject<ChampionRotation>(json);
        }
    }
}
