import React, { useState } from 'react'
import { Card, ListGroup } from 'react-bootstrap';

const Box = ({Box}) => {
    const [color, setColor] = useState("red")
    return (
      <Card style={{ width: "18rem", margin: "2rem" }}>
        <Card.Header style={{ color: color }}>{Box.nom}</Card.Header>
        <ListGroup variant="flush">
          <ListGroup.Item>Volume : {Box.volume} m³</ListGroup.Item>
          <ListGroup.Item>Superficie : {Box.superficie} m²</ListGroup.Item>
        </ListGroup>
      </Card>
    );
}

export default Box
