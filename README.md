# week7_mini_projekt
Small solo project as part of learning C# as part of my education.

## Task

- Classes Computer and Phone that Inherit from abstract class Asset.

- Asset can have date, price, name and office.

- Create list of Asset prepopulated with some Computer and Phone.

- Show user list of Asset sorted by office and then by date.

- Color Asset red in show user list if Asset date is less then 3 months or yellow if less then 6 months away from 3 years of current date.

- When showing user list of Asset, price shall be viewed in local currency of office. This by saving Asset price in dollar, but show a convered price to user. 

- Add meny to allow user to add new Asset and end program.

## post mortem

- All task done

### Improvment i wanted to have done if i hade more time.

- Use officeCurrency for handling currency in Utils.cs UserCreateAsset. But officeCurrency was created after UserCreateAsset.

- Find and implement a better way of handling Office, exchangeRates and officeCurrency what make it easy to add, change and remove options for office and its currency and exchange rates. Preferably in a way what it can be manage in one place without needing to update the code in other place like UserCreateAsset.