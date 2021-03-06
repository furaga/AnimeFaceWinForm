import numpy
import cv2
import sys
import os.path

def detect(filename, cascade_file = "lbpcascade_animeface.xml"):
    if not os.path.isfile(cascade_file):
        raise RuntimeError("%s: not found" % cascade_file)

    cascade = cv2.CascadeClassifier(cascade_file)
    image = cv2.imread(filename)
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    gray = cv2.equalizeHist(gray)
    
    faces = cascade.detectMultiScale(gray,
                                     # detector options
                                     scaleFactor = 1.1,
                                     minNeighbors = 5,
                                     minSize = (256, 256))
    
    faceCount = 0;
    for (x, y, w, h) in faces:
        print (x, y, w, h)

#        cv2.rectangle(image, (x, y), (x + w, y + h), (0, 0, 255), 2)

        if len(sys.argv) >= 3:
            filanameWithExtension = os.path.basename(sys.argv[1])
            filename = os.path.splitext(filanameWithExtension)[0]
            savepath = os.path.join(sys.argv[2], filename + "-" + str(faceCount) + ".png");
            cv2.imwrite(savepath, image[y:y+h,x:x+w])

        faceCount = faceCount + 1

#    cv2.imshow("AnimeFaceDetect", image)
#    cv2.waitKey(0)
#    cv2.imwrite("out.png", image)


if len(sys.argv) < 2:
    sys.stderr.write("usage: detect.py <filename> [<savedir>]\n")
    sys.exit(-1)
    
detect(sys.argv[1])
