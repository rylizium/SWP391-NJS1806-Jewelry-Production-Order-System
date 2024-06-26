import React, { useState, useEffect } from "react";
import { ref, getDownloadURL } from "firebase/storage";
import { storage } from "../../services/Firebase"; // Adjust the path according to your file structure

const FirebaseImage = ({path,alt}) => {
  const [imageUrl, setImageUrl] = useState(null);

  useEffect(() => {
    const fetchAndSetImageUrl = async () => {
      const imageRef = ref(storage, path);
      try {
        const url = await getDownloadURL(imageRef);
        setImageUrl(url);
      } catch (error) {
        console.error("Error getting download URL", error);
      }
    };

    fetchAndSetImageUrl();
  }, []);

  return (
    <>
      {imageUrl ? (
        <img src={imageUrl} alt={alt} className="object-cover " />
      ) : (
        <div className="object-cover w-full h-full"></div>
      )}
    </>
  );
};


export default FirebaseImage;
