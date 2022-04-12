# EventValue
## _Increase your productivity_

> Util, that Designed to **avode unnecessary boilerplate code** while using publisher-subscriber pattern in Unity

## Features

- Auto event on value changes
- Safety access to your variable via readonly interface
- Implicit casting to value and EventValue shell vise-versa

## Installation

### Via Package Manager

Find option "Add package from git URL..." and insert 

```
https://github.com/NickKhalow/EventValue.git?path=/Packages/EasyTools
```

### Copy-Paste Install

Downlaod https://github.com/NickKhalow/EventValue/tree/main/Packages/EasyTools directory and add to your Packages directory into your project

## Usage

### EventValue<T>

Main class that provides functionality of auto eventing

#### Initialize variable

```
private EventValue<int> _jumpCount;
```

#### Assign variable

```
private void Awake()
{
    _jumpCount = 0; // we can use implicit casting
}
```

#### Implicitly assign EventValue to Type

```
private EventValue<int> _jumpCount;
        
private void Save()
{
    PlayerPrefs.SetInt("MaxCount", _jumpCount);
}
```

#### Changing value

```
private void Update()
{
    if (Input.anyKeyDown)
        _jumpCount.Value++; //necessary change value only via Value property
}
```

#### Listening changes

```
private void Awake()
{
    _jumpCount.ValueChanged += JumpCountOnValueChanged;
}

private void JumpCountOnValueChanged(int obj)
{
    //TODO something with value
}

private void OnDestroy()
{
    _jumpCount.ValueChanged -= JumpCountOnValueChanged; //Don't forget unsubscribe
}
```

### IReadOnlyEventValue

Use when you need to ensure your client code can't modify value

#### Specification

Interface provides readonly access
- Event Action allows subscribe to value
- Value Property allows directly get current value 

```
public interface IReadOnlyEventValue<out T> where T : new()
    {
        /// <summary>
        /// Action notifies of any value changes  
        /// </summary>
        public event Action<T> ValueChanged;

        /// <summary>
        /// Returns current value.
        /// </summary>
        public T Value { get; }
    }
```

#### Upcasting
EventValue upcasts to IReadOnlyEventValue

```
private EventValue<int> _jumpCount;

public IReadOnlyEventValue<int> JumpCount => _jumpCount; 
```

### Example

With [this example](https://github.com/NickKhalow/EventValue/tree/main/Assets/EventValue%20Example) you can familiarize with EventValue util

## License

MIT

