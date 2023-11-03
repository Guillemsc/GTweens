namespace GTweens.Enums
{
    public enum ResetMode
    {
        /// <summary>
        /// Sets the initial values that the tween had when it started playing.
        /// </summary>
        InitialValues,
        
        /// <summary>
        /// Uses the difference between initial and the final values to increment the new initial and final values.
        /// </summary>
        IncrementalValues,
        
        /// <summary>
        /// Leaves the values as they are.
        /// </summary>
        CurrentValues,
    }
}