// eslint-disable-next-line no-unused-vars
import React from "react";
import {
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Typography,
  Stack,
  Avatar,
  Box,
  Container,
  Card,
  CardMedia,
  CardContent,
} from "@mui/material";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown";
import picture from "../images/anonymous-avatar.jpg";

// Mock data for projects
const projects = [
  {
    name: "Project nr.1 ",
    about: "Project met deelnemers(?) & autos.",
    participants: [
      {
        name: "Remy Sharp",
        img: picture,
      },
      {
        name: "Travis Howard",
        img: picture,
      },
    ],
    cars: [
      { title: "Toyota Supra", img: "https://source.unsplash.com/random?car1" },
      {
        title: "Nissan Skyline",
        img: "https://source.unsplash.com/random?car2",
      },
      { title: "Mazda RX-7", img: "https://source.unsplash.com/random?car3" },
    ],
  },
  {
    name: "Project nr.2",
    about: "Project met deelnemers(?) & autos.",
    participants: [
      {
        name: "Cindy Baker",
        img: picture,
      },
      {
        name: "Alice Johnson",
        img: picture,
      },
    ],
    cars: [
      {
        title: "Tesla Model S",
        img: "https://source.unsplash.com/random?car4",
      },
      { title: "Chevy Bolt", img: "https://source.unsplash.com/random?car5" },
      { title: "Nissan Leaf", img: "https://source.unsplash.com/random?car6" },
    ],
  },
];

const ProjectAccordion = () => {
  return (
    <Container style={{ padding: "20px 0" }} maxWidth="md">
      <Typography variant="h4" gutterBottom>
        Huidige projecten:
      </Typography>
      <Box
        display="flex"
        justifyContent="center"
        alignItems="center"
        minHeight="60vh"
        flexDirection="column"
        textAlign="center"
        margin="20px"
      >
        {projects.map((project, index) => (
          <Accordion key={index} style={{ marginBottom: "10px" }}>
            <AccordionSummary
              expandIcon={<ArrowDropDownIcon />}
              aria-controls={`panel${index + 1}-content`}
              id={`panel${index + 1}-header`}
            >
              <Typography>{project.name}</Typography>
            </AccordionSummary>
            <AccordionDetails>
              <Typography>{project.about}</Typography>

              <Typography style={{ marginTop: "10px" }}>
                Participants:
              </Typography>
              <Stack
                direction="row"
                spacing={2}
                style={{ marginBottom: "10px" }}
              >
                {project.participants.map((participant, pIndex) => (
                  <Avatar
                    key={pIndex}
                    alt={participant.name}
                    src={participant.img}
                  />
                ))}
              </Stack>

              <Typography>Leased Cars:</Typography>
              <Stack direction="row" spacing={2}>
                {project.cars.map((car, carIndex) => (
                  <Card key={carIndex} style={{ width: "30%" }}>
                    <CardMedia
                      className="card-media"
                      style={{ paddingTop: "56.25%" }}
                      image={car.img}
                      title={car.title}
                    />
                    <CardContent style={{ flexGrow: 1 }}>
                      <Typography gutterBottom variant="h5">
                        {car.title}
                      </Typography>
                      <Typography>
                        This section describes the content of the car card. Bla
                        bla bla.
                      </Typography>
                    </CardContent>
                  </Card>
                ))}
              </Stack>
            </AccordionDetails>
          </Accordion>
        ))}
      </Box>
    </Container>
  );
};

export default ProjectAccordion;
