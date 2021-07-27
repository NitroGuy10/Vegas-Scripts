using ScriptPortal.Vegas;

public class EntryPoint {
    public void FromVegas(Vegas vegas) {
        PlugInNode plugin = vegas.VideoFX.GetChildByName("VEGAS Picture In Picture");
        if (plugin == null)
        {
            throw new System.Exception("Failed to find plug-in: VEGAS Picture In Picture");
            return;
        }

        foreach (Track track in vegas.Project.Tracks)
        {
            foreach (TrackEvent trackEvent in track.Events)
            {
                if (trackEvent.Selected && trackEvent.MediaType == MediaType.Video)
                {
                    VideoEvent videoEvent = (VideoEvent) trackEvent;
                    bool skip = false;
                    foreach (Effect e in (videoEvent).Effects)
                    {
                        if (e.PlugIn.Name == "VEGAS Picture In Picture")
                        {
                            skip = true;
                            break;
                        }
                    }
                    if (!skip)
                    {
                        videoEvent.Effects.AddEffect(plugin);

                        OFXEffect effect = videoEvent.Effects[videoEvent.Effects.Count - 1].OFXEffect;
                        OFXDoubleParameter parameter = (OFXDoubleParameter) effect.FindParameterByName("Scale");
                        parameter.Value = 1d;
                        parameter.ParameterChanged();
                    }
                }
            }
        }
    }
}
