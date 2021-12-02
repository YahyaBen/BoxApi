import React, { useState } from 'react'
import { useQuery } from "react-query";
import Box from './Box';
const Boxs = () => {
    const [Color, setColor] = useState("red");
    const { data,isLoading } = useQuery("boxes", () =>
      fetch("https://localhost:7029/api/boxes").then((res) => res.json())
    );
    return (
        <div>
            {isLoading===false ? data.map(e=> <Box key={e.id} Box={e} color={Color}/>) : ""}
        </div>
    )
}

export default Boxs
