using ScriptPortal.Vegas;

public class EntryPoint {
    public void FromVegas(Vegas vegas) {
        foreach (Track track in vegas.Project.Tracks)
        {
            foreach (TrackEvent trackEvent in track.Events)
            {
                if (trackEvent.Start >= vegas.Transport.CursorPosition)
                {
                    trackEvent.Selected = true;
                }
            }
        }
    }
}
