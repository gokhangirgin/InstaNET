# [InstaNET](https://github.com/gokhangirgin/InstaNET) 

InstaNET is an OAuth2 Consumer for Instagram API 

You need to know that Instagram API responses contains generally 3 parts which are **meta**, **data** and **pagination** so  [IResponse<T>](https://github.com/gokhangirgin/InstaNET/blob/master/InstaNET/Response/IResponse.cs) covers that. In addition, IResponse contains limit member from [RateLimit](https://github.com/gokhangirgin/InstaNET/blob/master/InstaNET/Response/RateLimit.cs) that you can check Rate Limits after each request.

## How to use

[InstagramAPI](https://github.com/gokhangirgin/InstaNET/blob/master/InstaNET/InstagramAPI.cs) instance requires a [TokenManager](https://github.com/gokhangirgin/InstaNET/blob/master/InstaNET/TokenManager.cs) that keeps **access token** or **client Id** of your application.



```csharp
    using(InstagramAPI api = new InstagramAPI(new TokenManager(_accessToken:"",_clientId:"")))
    {
        IResponse<UserInfo> userInfo = api.Users.BasicInfo("314123");
        
    }
```
You can also have a look at [Tests](https://github.com/gokhangirgin/InstaNET/tree/master/Tests).

#### [InstagramAPI]((https://github.com/gokhangirgin/InstaNET/blob/master/InstaNET/InstagramAPI.cs) includes

```
InstagramAPI
├── Users
├── Media
├── Relationships
├── Comments
├── Likes
├── Tags
├── Locations
├── Geographies
├── Token

```

