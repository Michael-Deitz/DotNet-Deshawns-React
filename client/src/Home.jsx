import { getDogs, getGreeting } from "./apiManager";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

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
        <div><Link to={`/${dog.id}`}><h2>{dog.name}</h2></Link></div>

      </div>
    })}
  </div>;

  
}


