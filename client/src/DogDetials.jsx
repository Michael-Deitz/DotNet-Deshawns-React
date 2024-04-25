import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getDogDetails, getDogs } from "./apiManager"

export default function DogDetails() {
    const [dogs, setDogs] = useState([])
    const {dogId} = useParams()
    
    useEffect(() => {
      getDogDetails(dogId).then((dogArray) => {
        setDogs(dogArray)
      })
    }, [])
  
  
  return <div><header>Dog's Details</header>
    
        <div><h2>{dogs.name}</h2>
             <h3>Walker: {dogs.walker?.name}</h3>
             <h3>City: {dogs.city?.name}</h3></div>
      
    </div>
  }