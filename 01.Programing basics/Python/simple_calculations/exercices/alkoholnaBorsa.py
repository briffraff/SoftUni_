whiskeyPrice = float(input())
beerQuantity = float(input())
wineQuantity = float(input())
rakiaQuantity = float(input())
whiskeyQuantity = float(input())

rakiaPrice = whiskeyPrice / 2
winePrice = rakiaPrice * 0.6
beerPrice = rakiaPrice * 0.2

rakia = rakiaPrice * rakiaQuantity
whiskey = whiskeyPrice * whiskeyQuantity
beer = beerPrice * beerQuantity
wine = winePrice * wineQuantity

sum = rakia + whiskey + beer + wine

print(f"{sum:.2f}")