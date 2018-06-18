This is a small project that uses the Last.FM Api to create a list of lesser-known artists who are similar to an input artist.

<b>Usage</b>

  LowKey.exe "{ArtistName}",{ListenerCutoff}
  
  ListenerCutoff is the max number of listeners an artist can have before they're kicked off the list. 50000-100k is a good general range. More popular artists 
  
<b>Example</b>

  LowKey.exe "Metallica",250000
  
  
The Last.FM Api has a bunch of duplicate artists with no data behind them so sometimes super popular artists will pop up in the results with '0' listeners.
  
