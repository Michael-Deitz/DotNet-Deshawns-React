import { addDog, getDogs, getGreeting } from "./apiManager";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

export default function Home() {
  const [greeting, setGreeting] = useState({
    message: "Not Connected to the API",
  });
  
  const [dogs, setDogs] = useState([])
  const navigate = useNavigate()

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

  const handleCreate = () => {
    navigate(`/create`)
  }

  document.addEventListener(
    "click",
    (event) => {
      if (event.target.id === "addDog")
      addDog()
    }
  )

  return <div><header>{greeting.message}</header><div>YEEEEET</div>
      <div><button id="addDog" onClick={handleCreate}>Add A Dog</button></div>
    {dogs.map((dog) => {
      return <div> 
        <div><Link to={`/${dog.id}`}><h2>{dog.name}</h2></Link></div>

      </div>
    })}
  </div>;

  
}


