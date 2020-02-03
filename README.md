# Programming Integration Musicservice (Howestify)

## Spotify artists ID's

- Triggerfinger: 3UhIlk54Oe4ja06V962ptU
  - Followers: 143599
  - Genres
    - belgian rock
    - dutch indie
    - dutch rock
  - Images
    - height: 640
    - url: "https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9"
    - width: 640
    - height: 320
    - url: "https://i.scdn.co/image/8df00a835ac66507a55b6572491750bd41c7278c"
    - width: 320
    - height: 160
    - url: "https://i.scdn.co/image/13fd1ee7b9f8d3b1ca57d086d6ed7c171d052eb4"
    - width: 160
- AC/DC: 711MCceyCBcFnzjGY4Q7Un
  - Followers: 14124193
  - Genres - album rock - australian rock - hard rock - rock
    Images - height: 1500 - url: "https://i.scdn.co/image/a16c5d95ede008ec905d6ca6d1b5abbf39ad4566" - width: 1000 - height: 960 - url: "https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7" - width: 640 - height: 300 - url: "https://i.scdn.co/image/3d00e92fb05c62e2faf2908b34e6f24e0a4cb213" - width: 200 - height: 96 - url: "https://i.scdn.co/image/2940421b19c6b8a26b073ef340290516ea0399e1" - width: 64
- Nirvana: 6olE6TJLqED3rqDCT0FyPh
  - Followers: 10222671
  - Genres
    - alternative rock
    - grunge
    - permanent wave
    - post-grunge
    - rock
  - Images
    - height: 1057
    - url: "https://i.scdn.co/image/84282c28d851a700132356381fcfbadc67ff498b"
    - width: 1000
    - height: 677
    - url: "https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6"
    - width: 640
    - height: 211
    - url: "https://i.scdn.co/image/42ae0f180f16e2f21c1f2212717fc436f5b95451"
    - width: 200
    - height: 68
    - url: "https://i.scdn.co/image/e797ad36d56c3fc8fa06c6fe91263a15bf8391b8"
    - width: 64
- Flip Kowlier: 1u4ytAPuSMp7InqjzvVoTy
  - Followers: 12999
  - Genres
    - belgian rock
    - classic belgian pop
    - kleinkunst
    - west-vlaamse hip hop
  - Images
    - height: 640,
    - url: "https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754"
    - width: 640
    - height: 320
    - url: "https://i.scdn.co/image/b3897cc5dac721abe76fdf7c7266b3f9b51af73f"
    - width: 320
    - height: 160
    - url: "https://i.scdn.co/image/5bc9e60072958ace6e07fdd0c0dbeb65bd8764f3"
    - width: 160
- Metallica: 2ye2Wgw4gimLv2eAKyk1NB
  - Followers: 13031380
  - Genres
    - hard rock
    - metal
    - old school thrash
    - rock
    - speed metal
    - thrash metal
  - Images
    - height: 640
    - url: "https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91"
    - width: 640
    - height: 320
    - url: "https://i.scdn.co/image/0c22030833eb55c14013bb36eb6a429328868c29"
    - width: 320
    - height: 160
    - url: "https://i.scdn.co/image/c1fb4d88de092b5617e649bd4c406b5cab7d3ddd"
    - width: 160
  - Albums
    - Hardwired: 7LwifLL1anaEd9eIIfIkx7
      - name: H

## Genres

- hard rock
- metal
- old school thrash
- rock
- speed metal
- thrash metal
- belgian rock
- dutch indie
- dutch rock
- album rock
- australian rock
- alternative rock
- grunge
- permanent wave
- post-grunge
- belgian rock
- classic belgian pop
- kleinkunst
- west-vlaamse hip hop

public string AlbumType { get; set; }
    public List<Artist> Artists { get; set; }
    public List<string> AvailableMarkets { get; set; }
    public List<Copyright> Copyrights { get; set; }
    public ExternalIds ExternalIds { get; set; }
    public ExternalUrls ExternalUrls { get; set; }
    public List<object> Genres { get; set; }
    public Uri Href { get; set; }
    public string Id { get; set; }
    public List<Image> Images { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
    public long Popularity { get; set; }
    public DateTimeOffset ReleaseDate { get; set; }
    public string ReleaseDatePrecision { get; set; }
    public long TotalTracks { get; set; }
    public Tracks Tracks { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }