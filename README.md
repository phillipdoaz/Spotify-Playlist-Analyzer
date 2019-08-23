## Back End Task: Spotify Playlist Analyzer

**This requires a Spotify account, but it seems pretty cool, and we are trying to make the task entertaining**

The [Spotify API](https://developer.spotify.com/documentation/web-api/) provides a ton of useful functionality when interacting with songs, artists, and playlists.

Your client is a local DJ who just isn't getting as many wedding and party invites lately, and they think maybe its because of their music. They want a REST API (since DJs apparently know how to `cURL`) that will tell them about certain attributes of their playlists.

Using the [API reference](https://developer.spotify.com/documentation/web-api/reference/), they want you to create a wrapping API that allows them to give a playlist ID and will return them a JSON response containing the playlist's min, max, and average for the following values:

* Danceability
* Energy
* Valence

The response should *also* contain a rating for the playlist for how good this playlist is based on the previously analyzed values. You can generate this rating algorithm yourself, so feel free to make it as simple or as complex as you would like.

An example response may look like the following:

```javascript
{
    "danceability": {
        "min": 0.2,
        "max": 0.3,
    },
    // other attributes
    "overall": .6
}
```

#### Things to Consider

Not all of the following have to be accomplished, just do what you can. Remember, **quality is better than quantity**.

* How would you implement it in the response to include the highest rated and lowest rated song, in case the DJ wanted to be able to know/remove these? How about the highest and lowest k-th songs?
* How would you manage caching of these requests / results so that you ensure the following:
     1. Aren't recalculating the same playlist every time and 
     2. Aren't hitting the Spotify API every time?
* How could you implement some sort of user model that you could tie the playlists to, allowing a route such as the following to work?

    ```
    /api/users/1/stats
    {
        "stats": [
            {
                "playlist-id": 1,
                "danceability": {
                    "min": 0.2,
                    "max": 0.8,
                },
                // other attributes ...
                "overall": .6
            },
            {
                "playlist-id": 2,
                "danceability": {
                    "min": 0.4,
                    "max": 0.9,
                },
                // other attributes ...
                "overall": .8
            },
        ]
    }
    ```
