import React from 'react'
import { useQuery } from "react-query";
import Box from './Box';
const Boxs = () => {
    const { data } = useQuery("boxes", () =>
      fetch("https://localhost:7029/api/boxes").then((res) => res.json())
    );
    return (
        <div>
            {data ? data.map(e=> <Box key={e.id} Box={e}/>) : ""}
        </div>
    )
}

export default Boxs
