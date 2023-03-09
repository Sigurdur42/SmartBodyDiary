using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBodyDiaryDomain;
using Xunit;

namespace SmartBodyDiaryDomainTests.Persistence
{
    public class JsonPersistenceTest
    {
        [Fact]
        public void VerifySerializeAndDeserializeAreCompatible_WithData()
        {
            InternalSerializationTest(CreateData);
        }

        [Fact]
        public void VerifySerializeAndDeserializeAreCompatible_EmptyData()
        {
            InternalSerializationTest(CreateEmptyData);
        }

        private static void InternalSerializationTest(Func<PersistenceContainer> dataRetrieval)
        {
            var data = dataRetrieval();
            var target = new JsonPersistence();

            var serialized = target.Serialize(data);
            var deserialized = target.Deserialize(serialized);
            Assert.NotNull(deserialized);

            var serialized2 = target.Serialize(deserialized);
            Assert.Equal(serialized, serialized2);
        }
        private PersistenceContainer CreateData()
        {
            var random = new Random();
            var weights = new List<DiaryWeight>();
            var gymSessions = new List<GymSession>();
            var dailyGoals = new List<DailyGoals>();
            var challenges = new List<Challenge>();
            var bodyData = new List<BodyMeasurement>();
            for (var index = 0; index < 100; ++index)
            {
                var day = new DateOnly(2022, 01, 1).AddDays(index);
                weights.Add(new DiaryWeight(day, random.Next()));
                gymSessions.Add(new GymSession(day) { Progress = GymProgress.Progress });

                if (index % 5 == 0)
                {
                    dailyGoals.Add(new DailyGoals(day));
                    challenges.Add(new Challenge(day)
                    {
                        End = day.AddDays(7),
                        Title = $"dummy {index}"
                    });

                    bodyData.Add(new BodyMeasurement(day)
                    {
                        Belly = random.Next(),
                        BellyMinus5 = random.Next(),
                        BellyPlus5 = random.Next(),
                        Chest = random.Next(),
                        Hip = random.Next(),
                        LeftArm = random.Next(),
                        LeftLeg = random.Next(),
                        RightLeg = random.Next(),
                        RightArm = random.Next(),
                        Shoulder = random.Next(),
                    });
                }
            }

            return new PersistenceContainer()
            {
                Weights = weights.ToArray(),
                BodyData = bodyData.ToArray(),
                Challenges = challenges.ToArray(),
                DailyGoals = dailyGoals.ToArray(),
                GymSessions = gymSessions.ToArray()
            };
        }

        private PersistenceContainer CreateEmptyData() => new();
    }
}