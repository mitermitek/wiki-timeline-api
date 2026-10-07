namespace wiki_timeline_api.Enums;

public enum DateType
{
    // --- Life & Existence (People, Organizations, Places) ---

    /// <summary> Date of birth (P569) </summary>
    Birth,

    /// <summary> Date of death (P570) </summary>
    Death,

    /// <summary> Date of inception / foundation (P571) </summary>
    Inception,

    /// <summary> Date of dissolution / abolition (P576) </summary>
    Dissolution,

    // --- Works, Artifacts & Inventions ---

    /// <summary> Date of publication (P577) </summary>
    Publication,

    /// <summary> Date of discovery or invention (P575) </summary>
    Discovery,

    /// <summary> Date of production / manufacture (P1092) </summary>
    Production,

    // --- Events & Chronology ---
    /// <summary> Point in time of an event (P585) </summary>
    Event,

    /// <summary> Start time of a period, position, or event (P580) </summary>
    Start,

    /// <summary> End time of a period, position, or event (P582) </summary>
    End,

    // --- Operational & Official Milestones ---

    /// <summary> Date of signature (treaties, contracts) (P2913) </summary>
    Signature,

    /// <summary> Date of entry into force / effective date (P2241) </summary>
    Effective,

    /// <summary> Service entry / commissioning date (P729) </summary>
    Commissioning,

    /// <summary> Service retirement / decommissioning date (P730) </summary>
    Decommissioning
}