# SAXCoreLibrary
## Using ASP.NET Core 2.1
### Repositories with Unit Of Work and more.
---
## Requirements & Includes
* Dotnet Core 2.1
* Visual Studio 2017 (For Deploy codes)
---
## Design Patterns
* OOP (Interface, Abstract, Inheritance, Encapsulation, Polymorphism)
* Repositories
    * BaseRepository
    * Repository
* Unit of Work
    * UnitOfWork
* Dependency Injection
    * IRepository
    * ICRUDRepository
    * ISoftDeletable
    * IUnitOfWork
---
## Installation
    git clone https://github.com/SomboChea/SAXCoreLibrary.git
<br />

    cd SAX.CoreLibrary
    dotnet restore
    dotnet build
    
<br />

## Test (xUnit)

    cd SAXTestLabs
    dotnet restore
    dotnet test

<br />

# LICENSE

MIT License

Copyright (c) 2018 Sambo Chea

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
