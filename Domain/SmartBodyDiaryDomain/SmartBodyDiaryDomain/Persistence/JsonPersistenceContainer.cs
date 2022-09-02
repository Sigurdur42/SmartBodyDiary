﻿using SmartBodyDomain;

namespace SmartBodyDiaryDomain;

public class JsonPersistenceContainer
{
    public DiaryWeight[] Weights { get; set; } = Array.Empty<DiaryWeight>();
    public GymSession[] GymSessions { get; set; } = Array.Empty<GymSession>();
}