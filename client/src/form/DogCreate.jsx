import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { addDog, getCities } from "../apiManager"

export const DogCreate = () => {
    const [dog, setDogs] = useState({name: "", cityId: null})
    const [selectedCity, setSelectedCity] = useState([])
    const [uniqueCity, setUniqueCity] = useState([])
    const navigate = useNavigate()

    useEffect(() => {
        getCities().then((cityArray) => {
            setUniqueCity(cityArray)
        })
    }, [])

    const handleCreateDogName = (event) => {
        const copy = {...dog}
        copy.name = event.target.value
        setDogs(copy)
    }

    const handleCityChange = (event) => {
        const copy = {...dog}
        copy.cityId = event.target.value
        setDogs(copy)
    }

    const handlePost = (event) => {
        event.preventDefault()

            addDog(dog).then(dogObj => {
                navigate(`/${dogObj.id}`)
            })
        }
    
    return (
        <form>
            <h2>Add A Dog!</h2>
            <fieldset>
                <div>
                    <label>Dog Name:</label><input type="text" onChange={handleCreateDogName}/>
                </div>
            </fieldset>
            <fieldset>
                <div>
                    <label htmlFor="dropdown">City Dogs In:</label>
                    <select id="dropdown" value={selectedCity.city} onChange={handleCityChange}>
                        <option>-- Select --</option>
                        {uniqueCity.map((city) => {
                            return <option key={city.id} value={city.id}>{city.name}</option>
                        })}
                    </select>
                </div>
            </fieldset>
            <fieldset>
                <div>
                    <button onClick={handlePost}>Add Your Dog</button>
                </div>
            </fieldset>
        </form>
    )
}