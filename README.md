AnimeFaceWinForm
====================

**AnimeFaceWinForm** : A frontend software for  [AnimeFace](http://anime.udp.jp/imager-animeface.html).

Introduction
--------------------

The software searches anime character's faces in a video file (.mp4, .mov, .avi, .vob, ...).

The face recognition is internally processed by [AnimeFace](http://anime.udp.jp/imager-animeface.html).

![Imgur](http://i.imgur.com/IQhdHRL.png)

![Imgur](http://i.imgur.com/VEAz2QD.png)

Also, this software can take screenshots (of the primary screen) at a certain interval, and searches anime faces in the screenshots.

![Imgur](http://i.imgur.com/dR6i03p.png)

![Imgur](http://i.imgur.com/zauCFfM.png)

(Captured screenshots with playing http://www.nicovideo.jp/watch/1461737064)

Implementation and Requirements
--------------------

The software captures images from an input video using OpenCVSharp, 
and recognizes faces using a python script, ./AnimeFaceWinForm/bin/python/detect.py.

You need to install Python (>= 2.7.9), numpy (>= 1.9.2) and OpenCV.

I installed **Python 2.7.11 (32 bit)** from [the official web page](https://www.python.org/), numpy using **numpy-1.9.2-win32-superpack-python2.7.exe** from [sourceforge](https://sourceforge.net/projects/numpy/files/NumPy/1.9.2/), and installed OpenCV using **opencv-3.1.0.exe** from [sourceforge](https://sourceforge.net/projects/opencvlibrary/files/opencv-win/)

Then, I copied C:\opencv\build\python\2.7\x86\cv2.pyd into 
C:\Python27\Lib\site-packages, and added C:\Python27\Lib\site-packages to PYTHONPATH.

This software is implemented as a WinForm application with Visual C# 2013.
I confirmed this software works on both Windows 10 in ThinkPad X1 Carbon and Windows 7 in a desktop PC.


Licence
--------------------

The MIT License (MIT)

Copyright (c) 2016 furaga

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.