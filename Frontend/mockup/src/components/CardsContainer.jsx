import React from "react";
import {
  Typography,
  Container,
  Grid,
  Card,
  CardActions,
  CardMedia,
  CardContent,
} from "@mui/material";
import DetailsDialog from "./DetailsDialog";
import MessageDialog from "./MessageDialog";

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];

const CardsContainer = () => {
  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Grid container spacing={4}>
        {/* Grid item is 1 volledige mediacard */}
        {cards.map((card) => (
          <Grid item key={card} xs={12} sm={6} md={4}>
            <Card
              style={{
                height: "100%",
                display: "flex",
                flexDirection: "column",
              }}
            >
              <CardMedia
                className="card-media"
                style={{ paddingTop: "56.25%" }}
                image="https://source.unsplash.com/random?car"
                title="Image title"
              />
              <CardContent style={{ flexGrow: 1 }}>
                <Typography gutterBottom variant="h5">
                  Heading
                </Typography>
                <Typography>
                  Je kan deze sectie gebruiken om de content van de card te
                  beschrijven. bla bla bla
                </Typography>
              </CardContent>
              <CardActions>
                {/* <Button size="small" color="primary">
                      View details
                    </Button> */}
                <DetailsDialog imageUrl="https://source.unsplash.com/random?car" />
                <MessageDialog imageUrl="https://source.unsplash.com/random?" />
                {/* <Button size="small" color="primary" endIcon={<Send />}>
                      Send message
                    </Button> */}
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default CardsContainer;
