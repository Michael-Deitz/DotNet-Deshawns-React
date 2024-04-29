export const getGreeting = async () => {
  const res = await fetch("/api/hello");
  return res.json();
};

export const getDogs = async () => {
  const res = await fetch("/api/dogs")
  return res.json()
}

export const getDogDetails = async (id) => {
  const res = await fetch(`/api/dogs/${id}`)
  return res.json()
}

export const addDog = async (dogs) => {
 return await fetch(`/api/dogs/create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(dogs),
  }).then((res) => res.json())
}

export const getCities = async () => {
  const res = await fetch("/api/city")
  return res.json()
}