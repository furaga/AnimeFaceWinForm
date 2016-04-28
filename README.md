AnimeFaceWinForm
====================

AnimeFaceWinForm : A frontend for AnimeFace (http://anime.udp.jp/imager-animeface.html).

Introduction
--------------------

**AnimeFaceWinForm** is a frontend software for AnimeFace (http://anime.udp.jp/imager-animeface.html).

![Imgur](http://i.imgur.com/N8IzUC9.png)

![Imgur](http://i.imgur.com/VEAz2QD.png)

Implementation and Requirements
--------------------

The frontend processes an input video with OpenCVSharp, 
and conduct face recognition with CPython.
The face recognition script is ./AnimeFaceWinForm/bin/python/detect.py.

So, you need to install Python 2.7.

This software is implemented as a WinForm application with Visual C# 2013.
I confirmed this software works on ThinkPad X1 Carbon in Windows 10.


Licence
--------------------

The MIT License (MIT)

Copyright (c) 2016 furaga

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.