#RottenTomatoes.NET

RottenTomatoes.NET is a client library for the [RottenTomatoes.com public api](http://developer.rottentomatoes.com/). 

###Getting Started

**NOTE**: This library is currently for .NET 4.5 and later. There is also a PCL version for Windows Store and Windows Phone 8.1 apps. 

To use RottenTomates.NET you must first get an api key from Rotten Tomatoes.  
You can register for a key [here](http://developer.rottentomatoes.com/member/register)

Using your shiny new apikey you can access RottenTomatoes api by instatiating a new RottenTomatoesClient.

```
	var client = new RottenTomatoesClient(apiKey);
	
	var movies = await client.GetMoviesInTheatersAsync(); 

```  

Once you have can get access to all the data that Rotten Tomatoes public api exposes.

### Available APIs

##### Movies in theaters

* GetBoxOfficeMoviesAsync
* GetMoviesInTheatersAsync
* GetOpeningMoviesAsync
* GetUpcomingMoviesAsync

#### DVD Movies

* GetTopRentalMoviesAsync
* GetCurrentDvdReleasesAsync
* GetNewDvdReleasesAsync
* GetUpcomingDvdReleasesAsync


#### Movie Information
**NOTE:** movieId is the Rotten Tomatoes Id given to the movie  

* GetMovieAsync(movieId) 
* GetMovieClipsAsync(movieId)  
* GetMovieReviewsAsync(movieId)
* GetMovieCastAsync(movieId)

GetMovieAsync accepts optional parameters to eager load FullCast, Clips, Reviews

```  
	var client = new RottenTomatoesClient(apiKey);
	
	var movie = await client.GetMovieAsync(movieId,
		includeFullCast: true,
	    includeClips: true,
		includeReviews: true
	); 
```

