#Geocode

Basics:
C#
.NET 4.5.2
VS2015

I tested as I coded with the input.txt file.

At this time of this commit, there are no tests written.

Assuming valid input,  I parsed the file to a collection of strings.

Assumed the first line was the coordinates and created a map to identify each set of X and Y.  

Each other element in the string collection is an address to query a "point" for.

These "point sets" are paramaters for the PointExistsInPoly call.

I used the GoogleMaps Geocode API to query for the geoCode for each address (foolishly included the string in the commit).

The return from GeoCodeRetriever.GeoCodeRetrieveAddress is mapped into a GeoCode class of which we use very little data, but it was cool to see what was available from the api call.

Using the geometry.location.lat, and geometry.location.lng props of the GeoCode class, a Point is created.  This represents the address we want to math on.

This Point is passed to the PointExistsInPoly call.

Note we assume some parameters as the number of verices is hardcoded to 4.  
If more vertices are to be passed, I would refactor this to an object that contains the number of vertices and the coordinate map for X and Y.  This would also be ideal for mocking test objects.

I ripped the code from SO.
//https://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon



