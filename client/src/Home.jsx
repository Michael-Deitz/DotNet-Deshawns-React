import { getDogs, getGreeting } from "./apiManager";
import { useEffect, useState } from "react";

export default function Home() {
  const [greeting, setGreeting] = useState({
    message: "Not Connected to the API",
  });
  
  const [dogs, setDogs] = useState([])

  useEffect(() => {
    getGreeting()
      .then(setGreeting)
      .catch(() => {
        console.log("API not connected");
      });
  }, []);

  useEffect(() => {
    getDogs().then((dogArray) => {
      setDogs(dogArray)
    })
  }, [])

  return <div><header>{greeting.message}</header><div>YEEEEET</div>
    {dogs.map((dog) => {
      return <div> 
        <div><h2>{dog.name}</h2></div>

      </div>
    })}
  </div>;

  
}
